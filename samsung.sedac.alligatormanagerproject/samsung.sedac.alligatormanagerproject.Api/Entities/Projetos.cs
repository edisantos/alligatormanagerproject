using System;

namespace samsung.sedac.alligatormanagerproject.Api.Entities
{
    public class Projetos
    {
        public int Id{ get; set; }
        public DateTime Data { get; set; }
        public string Solicitante { get; set; }
        public int DepartamentoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string UrlFluxograma { get; set; }
        public int IsApproved { get; set; }
    }
}
