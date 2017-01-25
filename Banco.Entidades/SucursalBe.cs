﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Banco.Entidades
{
    public class SucursalBe
    {
        public int IdSucursal { set; get; }
        [Required(ErrorMessage = "Seleccione el Banco")]
        [Display(Name = "Nombre de Banco")]
        public int IdBanco { set; get; }        
        public string NombreBanco { set; get; }
        [Required(ErrorMessage = "Ingrese el Nombre")]
        [Display(Name = "Nombre")]
        [StringLength(200, ErrorMessage = "El Nombre debe contener mas de 5 caracteres", MinimumLength = 5)]
        public string Nombre { set; get; }
        [Required(ErrorMessage = "Ingrese la Dirección")]
        [Display(Name = "Dirección")]
        [StringLength(200, ErrorMessage = "La dirección debe contener mas de 5 caracteres", MinimumLength = 5)]
        public string Direccion { set; get; }
        public DateTime FechaRegistro { set; get; }
        public string FechaRegistroStr { get { return FechaRegistro.ToShortDateString(); } }
        public IEnumerable<SelectListItem> BancoList { get; set; }
    }
}
