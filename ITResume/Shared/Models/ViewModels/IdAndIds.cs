using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.ViewModels;

public class IdAndIds<T1, T2>
{
    public T1 Id { get; set; } = default!;
    public IEnumerable<T2> Ids { get; set; } = default!;
}
