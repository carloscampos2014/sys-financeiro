﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioUsuarioSistemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioUsuarioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuarioSistemaFinanceiroAsync(int IdSistema)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.UsuarioSistemaFinanceiro
                    .Where(us => us.IdSistema.Equals(IdSistema)).AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmailAsync(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.UsuarioSistemaFinanceiro
                    .AsNoTracking()
                    .FirstOrDefaultAsync(us => us.EmailUsuario.Equals(emailUsuario));
            }
        }

        public async Task RemoverUsuariosAsync(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                banco.UsuarioSistemaFinanceiro
                    .RemoveRange(usuarios);
                await banco.SaveChangesAsync();
            }
        }
    }
}
