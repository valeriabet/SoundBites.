using System;
using System.Collections.Generic;

namespace SoundBitesAPI.Models;

public partial class Favorito
{
    public int IdFavorito { get; set; }

    public int IdUsuario { get; set; }

    public int IdPlato { get; set; }

    public virtual Plato IdPlatoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
