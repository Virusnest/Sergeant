using System;
using System.Text;

namespace Sergeant.Arguments;

public class BoolArgument : Argument {
  public override object? Parse(StringReader argument) {
    //r 
    StringBuilder stringBuilder = new StringBuilder();

    while (argument.Peek() != ' ' && argument.Peek() != -1) {
      stringBuilder.Append((char)argument.Read());
    }

    string value = stringBuilder.ToString();
    if (value == "true" || value == "1") {
      return true;
    }
    if (value == "false" || value == "0") {
      return false;
    }
    throw new CommandSyntaxException("Invalid boolean value.");
  }
}
