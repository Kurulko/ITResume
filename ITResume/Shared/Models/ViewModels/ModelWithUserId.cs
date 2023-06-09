using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.ViewModels;

public record ModelWithUserId<T>(string UserId, T Model);