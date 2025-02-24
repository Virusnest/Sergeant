using System;
using System.Text;

namespace Sergeant.Arguments;

public class StringArgument : Argument {
  public override object? Parse(StringReader argument) {
    StringBuilder stringBuilder = new StringBuilder();

    if (argument.Peek() == '"') {
      argument.Read();
      while ((argument.Peek() != '"') && (argument.Peek() != -1)) {
        stringBuilder.Append((char)argument.Read());
      }
      if (argument.Peek() != '"') {
        throw new CommandSyntaxException("Unclosed string argument.");
      }
      argument.Read();
      return stringBuilder.ToString();
    }
    else {
      while (argument.Peek() != ' ' && argument.Peek() != -1) {
        stringBuilder.Append((char)argument.Read());
      }
    }
    return stringBuilder.ToString();
  }
}
