using System;

namespace Sergeant;

public class CommandContext {
  public int RequiredCommandCount;
  public CommandContext(List<Argument> arguments, Func<Command, CommandCallback> action) {
    Arguments = arguments;
    Action = action;
  }
  public CommandContext() { }
  public List<Argument> Arguments = new List<Argument>();
  public Func<Command, CommandCallback> Action = (command) => new CommandCallback();
}
