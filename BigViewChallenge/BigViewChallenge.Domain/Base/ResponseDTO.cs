using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigViewChallenge.Domain.Base;

public class ResponseDTO
{
    public string Error { get; set; } = string.Empty;
    public object Data { get; set; }
    public bool Success { get; set; }
}
