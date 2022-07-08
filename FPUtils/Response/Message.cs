using System.Collections.Generic;

namespace FPUtils.Response
{
   public enum MessageType : byte {
      Information = 0,
      Warning = 1,
      Error = 2
   }

   public abstract class Message {
      private readonly List<Variable> _variables = new List<Variable>();

      public MessageType Type { get; set; }
      public string Code { get; set; }
      public string Text { get; set; }
      public IReadOnlyCollection<Variable> Variables => _variables.AsReadOnly();

      public Message() { }

      public Message(MessageType type, string text) : this(type, string.Empty, text) { }

      public Message(MessageType type, string code, string text, IEnumerable<Variable> variables) : this(type, code, text) { 
         _variables.AddRange(variables);
      }

      public Message(MessageType type, string code, string text) {
         Type = type;
         Code = code;
         Text = text;
      }

      public override string ToString() {
         return $"{nameof(Code)}: {Code}, {nameof(Text)}: {Text}";
      }

      public void AddVariable(string name, string value) {
         var variable = new Variable { Name = name, Value = value };
         _variables.Add(variable);
      }
   }

   public class InformationMessage : Message {
      public InformationMessage() : base() { }

      public InformationMessage(string text) : base(MessageType.Information, string.Empty, text) { }

      public InformationMessage(string code, string text) : base(MessageType.Information, code, text) { }

      public InformationMessage(string code, string text, IEnumerable<Variable> variables) : base(MessageType.Information, code, text, variables) { }
   }

   public class ErrorMessage : Message {
      public ErrorMessage() : base() { }

      public ErrorMessage(string text) : base(MessageType.Error, string.Empty, text) { }

      public ErrorMessage(string code, string text) : base(MessageType.Error, code, text) { }

      public ErrorMessage(string code, string text, IEnumerable<Variable> variables) : base(MessageType.Error, code, text, variables) { }
   }

   public class WarningMessage : Message
   {
      public WarningMessage() : base() { }

      public WarningMessage(string text) : base(MessageType.Warning, string.Empty, text) { }

      public WarningMessage(string code, string text) : base(MessageType.Warning, code, text) { }

      public WarningMessage(string code, string text, IEnumerable<Variable> variables) : base(MessageType.Warning, code, text, variables) { }
   }
}
