﻿/*
The next code was generated by Repository Pattern Generator.
Be free to modify this file.

This extension was developed and designed by Francisco López Sánchez.
*/

using Repository.Model;
using DataModel.ViewModel;

namespace Repository.Adapter
{
    public class UsuarioAdapter : Adapter<Usuario, UsuarioModel>
    {
        public override Usuario FromViewModel(UsuarioModel model)
        {
            return new Usuario()
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
                Nombre = model.Nombre,
                Apellidos = model.Apellidos,
                Avatar = model.Avatar
            };
        }

        public override UsuarioModel FromModel(Usuario model)
        {
            return new UsuarioModel()
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
                Nombre = model.Nombre,
                Apellidos = model.Apellidos,
                Avatar = model.Avatar
            };
        }
    }
}
