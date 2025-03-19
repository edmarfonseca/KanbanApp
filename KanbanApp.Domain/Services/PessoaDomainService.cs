using KanbanApp.Domain.Dtos.Requests;
using KanbanApp.Domain.Dtos.Responses;
using KanbanApp.Domain.Entities;
using KanbanApp.Domain.Helpers;
using KanbanApp.Domain.Interfaces.Repositories;
using KanbanApp.Domain.Interfaces.Security;
using KanbanApp.Domain.Interfaces.Services;
using KanbanApp.Domain.Validations;
using FluentValidation;

namespace KanbanApp.Domain.Services
{
    public class PessoaDomainService : IPessoaDomainService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ITokenSecurity _tokenSecurity;

        public PessoaDomainService(IPessoaRepository pessoaRepository, ITokenSecurity tokenSecurity)
        {
            _pessoaRepository = pessoaRepository;
            _tokenSecurity = tokenSecurity;
        }

        public CriarPessoaResponse Criar(CriarPessoaRequest request)
        {
            var pessoa = new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha
            };

            var validator = new PessoaValidator();
            var result = validator.Validate(pessoa);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (_pessoaRepository.VerifyExists(pessoa.Email))
                throw new ApplicationException("O email informado já está cadastrado. Tente outro.");


            pessoa.Senha = SHA256Helper.Encrypt(request.Senha);
            _pessoaRepository.Add(pessoa);

            var response = new CriarPessoaResponse
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Email = pessoa.Email,
                DataHoraCadastro = DateTime.Now
            };

            return response;
        }

        public AutenticarPessoaResponse Autenticar(AutenticarPessoaRequest request)
        {
            var pessoa = _pessoaRepository.Get(request.Email, SHA256Helper.Encrypt(request.Senha));

            if (pessoa == null)
                throw new ApplicationException("Acesso negado! Informações incorretas!");

            var response = new AutenticarPessoaResponse
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Email = pessoa.Email,
                DataHoraAcesso = DateTime.Now,
                DataHoraExpiracao = _tokenSecurity.GetExpirationDate(),
                Token = _tokenSecurity.CreateToken(pessoa.Id)
            };

            return response;
        }
    }
}