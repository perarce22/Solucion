using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Banco.Entidades
{
    public class OrdenPagoBe
    {
        public int IdOrden { set; get; }
        [Required(ErrorMessage = "Seleccione la Sucursal")]
        [Display(Name = "Nombre de la Sucursal")]
        public int IdSucursal { set; get; }
        public string Sucursal { set; get; }
        [Display (Name ="Monto")]
        [Required(ErrorMessage = "Ingrese el monto")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Monto { set; get; }
        [Required(ErrorMessage = "Seleccione la Moneda")]
        [Display(Name = "Nombre de la Moneda")]
        public int IdMoneda { set; get; }
        [Display(Name = "Nombre de la Moneda")]
        public string Moneda { set; get; }
        [Required(ErrorMessage = "Seleccione el Estado")]
        [Display(Name = "Nombre del Estado")]
        public int IdEstado { set; get; }
        [Display(Name = "Nombre del Estado")]
        public string Estado { set; get; }
        [Display(Name = "Nombre del Banco")]
        public int IdBanco { set; get; }
        [Display(Name = "Nombre del Banco")]
        public string Banco { set; get; }
        public DateTime FechaRegistro { set; get; }
        public string FechaRegistroStr { get { return FechaRegistro.ToShortDateString(); } }
        
        public IEnumerable<SelectListItem> BancosList { get; set; }
        public IEnumerable<SelectListItem> SucursalList { get; set; }

        public IEnumerable<SelectListItem> MonedaList { get; set; }
        
        public IEnumerable<SelectListItem> EstadoList { get; set; }
    }
}
