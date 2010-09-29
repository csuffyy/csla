﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Bxf
{
  /// <summary>
  /// Responsible for creating a fully populated IView
  /// object.
  /// </summary>
  public class ViewFactory : IViewFactory
  {
    /// <summary>
    /// Creates a populated IView object, including
    /// the instance of the view.
    /// </summary>
    /// <param name="viewName">Name of the view.</param>
    /// <param name="bindingResourceKey">Name of the binding resource.</param>
    /// <param name="model">Reference to the model or viewmodel for the view.</param>
    public IView GetView(string viewName, string bindingResourceKey, object model)
    {
      return new View(viewName, CreateUserControl(viewName), bindingResourceKey, model);
    }

    /// <summary>
    /// Creates an instance of the view.
    /// </summary>
    /// <param name="viewName">Name of the view.</param>
    protected virtual UserControl CreateUserControl(string viewName)
    {
      if (string.IsNullOrEmpty(viewName))
        return null;

      var t = Csla.Reflection.MethodCaller.GetType(viewName);
      if (t == null)
        throw new ArgumentException(string.Format("viewName ({0})", viewName));
      return (UserControl)Activator.CreateInstance(t);
    }
  }
}