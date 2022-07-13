using FPUtils.Extensions;
using System.Collections.Generic;

namespace FPUtils.Response
{
   public enum MessageType : byte
   {
      Information = 0,
      Warning = 1,
      Error = 2
   }

   public interface IMessage { }

   public abstract class Message : IMessage
   {
      private readonly List<Variable> _variables = new List<Variable>();
      public MessageType Type { get; protected set; }
      public string Code { get; set; }
      public string Text { get; set; }
      public IReadOnlyCollection<Variable> Variables => _variables.AsReadOnly();

      public Message(MessageType type)
      {
         Type = type;
      }

      public Message(MessageType type, string code, string text)
      {
         Type = type;
         Code = code;
         Text = text;
      }

      public Message(MessageType type, string text) : this(type, string.Empty, text) { }

      public Message(MessageType type, string code, string text, IEnumerable<Variable> variables) : this(type, code, text)
      {
         _variables.AddRange(variables);
      }

      public override string ToString()
      {
         return $"{nameof(Code)}: {Code}, {nameof(Text)}: {Text}";
      }

      /// <summary>
      /// Add new variable to the massage
      /// </summary>
      /// <param name="name">The variable name</param>
      /// <param name="value">The variable value</param>
      public void AddVariable(string name, string value)
      {
         var variable = new Variable { Name = name, Value = value };
         _variables.Add(variable);
      }


      /// <summary>
      /// Show the Text value. If any variable is used, the parse is done
      /// There are three ways to use variables
      /// 1. using only the name. 
      /// 2. using {}
      /// 3. using []
      /// </summary>
      public string Show() {
         string text = Text;

         if (_variables.HasData())
         {
            foreach(var variable in _variables)
            {
               text = text.Replace("{" + variable.Name + "}", variable.Value);
               text = text.Replace("[" + variable.Name + "]", variable.Value);
               text = text.Replace(variable.Name, variable.Value);
            }
         }

         return text;
      }
   }

   public class InformationMessage : Message
   {
      public InformationMessage() : base(MessageType.Information) { }

      public InformationMessage(string text) : base(MessageType.Information, string.Empty, text) { }

      public InformationMessage(string code, string text) : base(MessageType.Information, code, text) { }

      public InformationMessage(string code, string text, IEnumerable<Variable> variables) : base(MessageType.Information, code, text, variables) { }
   }

   public class ErrorMessage : Message
   {
      public ErrorMessage() : base(MessageType.Error) { }

      public ErrorMessage(string text) : base(MessageType.Error, string.Empty, text) { }

      public ErrorMessage(string code, string text) : base(MessageType.Error, code, text) { }

      public ErrorMessage(string code, string text, IEnumerable<Variable> variables) : base(MessageType.Error, code, text, variables) { }
   }

   public class WarningMessage : Message
   {
      public WarningMessage() : base(MessageType.Warning) { }

      public WarningMessage(string text) : base(MessageType.Warning, string.Empty, text) { }

      public WarningMessage(string code, string text) : base(MessageType.Warning, code, text) { }

      public WarningMessage(string code, string text, IEnumerable<Variable> variables) : base(MessageType.Warning, code, text, variables) { }
   }
}
