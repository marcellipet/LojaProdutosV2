﻿using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;

namespace LojaProdutosV2.Services.Endereco
{
    public interface IEnderecoInterface
    {
        Task<ResponseModel<List<EndEndereco>>> ListarTodos();
        Task<ResponseModel<EndEndereco>> BuscarPorId(long Id);
        Task<ResponseModel<EndEndereco>> BuscarPorIdUsuario(long Id);
        Task<ResponseModel<EndEndereco>> Criar(EndEndereco endereco);
        Task<ResponseModel<List<EndEndereco>>> Atualizar(EnderecoAtualizarDto enderecoAtualizar);
        Task<ResponseModel<bool>> Deletar(long Id);
    }
}
