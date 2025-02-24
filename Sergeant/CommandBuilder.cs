namespace Sergeant;

public class CommandBuilder {
  private CommandContext Context { get; } = new();

  public static CommandBuilder BeginCommand() {
    return new CommandBuilder();
  }

  public CommandContext Build(Func<Command, CommandCallback> action) {
    Context.Action = action;
    return Context;
  }

  public CommandBuilder AddArgument(string name, Argument argument, bool required = true) {
    argument.Name = name;
    argument.Required = required;
    var last = Context.Arguments.Count > 0 && !Context.Arguments[^1].Required;
    if (last == required) throw new CommandBuilderException("Required argument cannot follow optional argument.");
    if (required) Context.RequiredCommandCount++;
    Context.Arguments.Add(argument);
    return this;
  }
}