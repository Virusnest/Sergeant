using System;
using System.Text;

namespace Sergeant.Arguments;

public class NumberArgument : Argument {
  static string NUMBERCHARS = "0123456789.-";
  public override object? Parse(StringReader argument) {
    StringBuilder stringBuilder = new StringBuilder();
    if (!NUMBERCHARS.Contains((char)argument.Peek())) {
      throw new CommandSyntaxException("Expected a number.");
    }
    char peek;
    bool hasDecimal = false;
    while (NUMBERCHARS.Contains(peek = (char)argument.Peek())) {
      if (peek == '.') {
        if (hasDecimal) {
          throw new CommandSyntaxException("Invalid number format.");
        }
        hasDecimal = true;
      }
      stringBuilder.Append((char)argument.Read());

    }

    char type = (char)argument.Peek();


    try {
      if (argument.Peek() == -1) {
        if (hasDecimal) {

          return float.Parse(stringBuilder.ToString());
        }
        return int.Parse(stringBuilder.ToString());
      }
      switch (type) {
        case 'b':
          argument.Read();
          return byte.Parse(stringBuilder.ToString());
        case 's':
          argument.Read();
          return short.Parse(stringBuilder.ToString());
        case 'l':
          argument.Read();
          return long.Parse(stringBuilder.ToString());
        case 'f':
          argument.Read();
          return float.Parse(stringBuilder.ToString());
        case 'd':
          argument.Read();
          return double.Parse(stringBuilder.ToString());
        case 'i':
          argument.Read();
          return int.Parse(stringBuilder.ToString());
        default:
          throw new CommandSyntaxException("Invalid number type.");
      }
    }
    catch (OverflowException) {
      throw new CommandSyntaxException("Number is too large.");
    }
    catch {
      throw new CommandSyntaxException("Invalid Number Type");
    }

    // Add a return statement here
    throw new CommandSyntaxException("Invalid number type.");
  }
}
