using System;

namespace Sergeant;

/// <summary>
/// Parrses a command's argumments and returns a Executable Command
/// </summary>
public class CommandParser {
  StringReader reader;

  public CommandParser(string args) {
    reader = new StringReader(args);
  }

  public Command Parse(CommandContext context) {
    var contextEnumrator = context.Arguments.GetEnumerator();
    Dictionary<string, object?> args = new Dictionary<string, object?>();
    contextEnumrator.MoveNext();
    int count = 0;
    while (reader.Peek() != -1 && count < context.Arguments.Count) {
      args.Add(contextEnumrator.Current.Name, contextEnumrator.Current.Parse(reader));
      reader.Read();
      count++;
      contextEnumrator.MoveNext();
      if (reader.Peek() == -1 && count < context.Arguments.Count) {
        throw new CommandSyntaxException("Not enough arguments.");
      }
    }
    if (count < context.RequiredCommandCount) {
      throw new CommandSyntaxException("Not enough arguments.");
    }
    if (reader.Peek() != -1) {
      throw new CommandSyntaxException("Too many arguments.");
    }

    return new Command(context.Action, args);
  }

}
