using System;

namespace Sergeant;

public class Argument {
  public string Name { get; set; }
  public bool Required { get; set; } = true;
  public virtual object? Parse(StringReader argument) {
    return null;
  }
}
