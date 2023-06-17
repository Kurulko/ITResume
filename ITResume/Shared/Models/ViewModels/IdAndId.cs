using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.ViewModels;

public class IdAndId<T1, T2>
{
    public T1 Id1 { get; set; } = default!;
    public T2 Id2 { get; set; } = default!;
}
