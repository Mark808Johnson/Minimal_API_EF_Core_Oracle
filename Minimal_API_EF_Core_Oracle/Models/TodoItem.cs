using System;
using System.Collections.Generic;

namespace Minimal_API_EF_Core_Oracle.Models;

public class TodoItem
{
    public int Id { get; set; }

    public string Description { get; set; }

    public DateTimeOffset CreationTs { get; set; }

    public bool Done { get; set; }
}

