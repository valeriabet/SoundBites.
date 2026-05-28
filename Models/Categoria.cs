using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoundBitesAPI.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;
}