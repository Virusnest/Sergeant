using System;

namespace Sergeant;

public class Command {
  public Func<Command, CommandCallback> Action { get; set; }
  public Dictionary<string, object?> Arguments { get; set; } = new Dictionary<string, object?>();
  public Command(Func<Command, CommandCallback> action, Dictionary<string, object?> arguments) {
    Action = action;
    Arguments = arguments;
  }

  public CommandCallback Execute() {
    return Action(this);
  }

}