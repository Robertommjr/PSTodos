﻿using PSTodos.Model.Entities;

namespace PSTodos.Infrastructure.Repository.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario ObterComPerfil(int id);
        Usuario Atualizar(Usuario usuario, int id);
    }
}
