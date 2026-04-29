using System;
using System.Collections.Generic;

namespace SoundBitesAPI.Models;

public partial class Voto
{
    public int IdVoto { get; set; }

    public int IdUsuario { get; set; }

    public int IdGenero { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Genero IdGeneroNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
