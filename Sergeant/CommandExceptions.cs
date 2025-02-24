using System;

namespace Sergeant;

public class CommandSyntaxException : Exception {
  public CommandSyntaxException(string message) : base(message) { }

  public CommandSyntaxException() { }

}
public class CommandExecutionException : Exception {
  public CommandExecutionException(string message) : base(message) { }

  public CommandExecutionException() { }
}
public class CommandBuilderException : Exception {
  public CommandBuilderException(string message) : base(message) { }

  public CommandBuilderException() { }
}