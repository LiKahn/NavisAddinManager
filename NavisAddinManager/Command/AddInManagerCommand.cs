﻿using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Autodesk.Navisworks.Api.Plugins;
using RevitAddinManager.Model;
using MessageBox = System.Windows.MessageBox;

namespace NavisAddinManager.Command;

public abstract class IAddinCommand
{
    public abstract int Action(params string[] parameters);

    public void Execute(params string[] parameters)
    {
        try
        {
            Action(parameters);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
    }
}
/// <summary>
/// Executer the command Addin Manager Manual
/// </summary>
public class AddInManagerManual : IAddinCommand
{
    public override int Action(params string[] parameters)
    {
        Debug.Listeners.Clear();
        Trace.Listeners.Clear();
        CodeListener codeListener = new CodeListener();
        Debug.Listeners.Add(codeListener);
        return AddinManagerBase.Instance.ExecuteCommand(false, parameters);
    }
}

/// <summary>
/// Execute the command Addin Manager Faceless
/// </summary>
public class AddInManagerFaceLess : IAddinCommand
{
    public override int Action(params string[] parameters)
    {
        return AddinManagerBase.Instance.ExecuteCommand(true, parameters);
    }
}

public class Test : IAddinCommand
{
    public override int Action(params string[] parameters)
    {
        MessageBox.Show("Hello World");
        return 0;
    }
}
