﻿using LojaProdutos.Models;
using LojaProdutosV2.Models;

namespace LojaProdutosV2.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsrUsuario>>> PegarTodos();
        Task<ResponseModel<UsrUsuario>> BuscarPorId(long Id);
        Task<ResponseModel<UsrUsuario>> Criar(UsrUsuario usuario);
        Task<ResponseModel<UsrUsuario>> Atualizar(UsrUsuario usuario);
        Task<ResponseModel<bool>> Deletar(long Id);
    }
}
