using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Enums
{
    public enum Plano
    {
        [Description("FaleMais 30")]
        FaleMais30 = 30,
        [Description("FaleMais 60")]
        FaleMais60 = 60,
        [Description("FaleMais 120")]
        FaleMais120 = 120,
        [Description("Todos")]
        Todos = 0
    }
}
