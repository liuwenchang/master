/*
* MATLAB Compiler: 6.1 (R2015b)
* Date: Tue Mar 27 21:31:01 2018
* Arguments: "-B" "macro_default" "-W" "dotnet:zjtMatlab,NoiseReduce,0.0,private" "-T"
* "link:lib" "-d" "G:\zhangjiantaoPro\matlab\zjtMatlab\for_testing" "-v"
* "class{NoiseReduce:C:\Users\liuxiaochang\Desktop\程序1\程序\Direct.m,C:\Users\liuxiaocha
* ng\Desktop\程序1\程序\去噪\DoubleDataExp.m,C:\Users\liuxiaochang\Desktop\程序1\程序\Inpu
* tData.m,C:\Users\liuxiaochang\Desktop\程序1\程序\双源定位\Location.m,C:\Users\liuxiaocha
* ng\Desktop\程序1\程序\去噪\W4Denoise.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace zjtMatlab
{

  /// <summary>
  /// The NoiseReduce class provides a CLS compliant, MWArray interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\liuxiaochang\Desktop\程序1\程序\Direct.m
  /// <newpara></newpara>
  /// C:\Users\liuxiaochang\Desktop\程序1\程序\去噪\DoubleDataExp.m
  /// <newpara></newpara>
  /// C:\Users\liuxiaochang\Desktop\程序1\程序\InputData.m
  /// <newpara></newpara>
  /// C:\Users\liuxiaochang\Desktop\程序1\程序\双源定位\Location.m
  /// <newpara></newpara>
  /// C:\Users\liuxiaochang\Desktop\程序1\程序\去噪\W4Denoise.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class NoiseReduce : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static NoiseReduce()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

          int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "zjtMatlab.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the NoiseReduce class.
    /// </summary>
    public NoiseReduce()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~NoiseReduce()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the Direct MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// m=8;
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Direct()
    {
      return mcr.EvaluateFunction("Direct", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the Direct MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// m=8;
    /// </remarks>
    /// <param name="dataPath">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Direct(MWArray dataPath)
    {
      return mcr.EvaluateFunction("Direct", dataPath);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the Direct MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// m=8;
    /// </remarks>
    /// <param name="dataPath">Input argument #1</param>
    /// <param name="index">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Direct(MWArray dataPath, MWArray index)
    {
      return mcr.EvaluateFunction("Direct", dataPath, index);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the Direct MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// m=8;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Direct(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Direct", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the Direct MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// m=8;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="dataPath">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Direct(int numArgsOut, MWArray dataPath)
    {
      return mcr.EvaluateFunction(numArgsOut, "Direct", dataPath);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the Direct MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// m=8;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="dataPath">Input argument #1</param>
    /// <param name="index">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Direct(int numArgsOut, MWArray dataPath, MWArray index)
    {
      return mcr.EvaluateFunction(numArgsOut, "Direct", dataPath, index);
    }


    /// <summary>
    /// Provides an interface for the Direct function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// m=8;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void Direct(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("Direct", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the DoubleDataExp MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// set(gcf,'Visible','off');
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DoubleDataExp()
    {
      return mcr.EvaluateFunction("DoubleDataExp", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the DoubleDataExp MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// set(gcf,'Visible','off');
    /// </remarks>
    /// <param name="dataPath">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DoubleDataExp(MWArray dataPath)
    {
      return mcr.EvaluateFunction("DoubleDataExp", dataPath);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the DoubleDataExp MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// set(gcf,'Visible','off');
    /// </remarks>
    /// <param name="dataPath">Input argument #1</param>
    /// <param name="index">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DoubleDataExp(MWArray dataPath, MWArray index)
    {
      return mcr.EvaluateFunction("DoubleDataExp", dataPath, index);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the DoubleDataExp MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// set(gcf,'Visible','off');
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] DoubleDataExp(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "DoubleDataExp", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the DoubleDataExp MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// set(gcf,'Visible','off');
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="dataPath">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] DoubleDataExp(int numArgsOut, MWArray dataPath)
    {
      return mcr.EvaluateFunction(numArgsOut, "DoubleDataExp", dataPath);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the DoubleDataExp MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// set(gcf,'Visible','off');
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="dataPath">Input argument #1</param>
    /// <param name="index">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] DoubleDataExp(int numArgsOut, MWArray dataPath, MWArray index)
    {
      return mcr.EvaluateFunction(numArgsOut, "DoubleDataExp", dataPath, index);
    }


    /// <summary>
    /// Provides an interface for the DoubleDataExp function in which the input and
    /// output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// set(gcf,'Visible','off');
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void DoubleDataExp(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("DoubleDataExp", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the InputData MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    ///
    public void InputData()
    {
      mcr.EvaluateFunction(0, "InputData", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the InputData MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="dataPath">Input argument #1</param>
    ///
    public void InputData(MWArray dataPath)
    {
      mcr.EvaluateFunction(0, "InputData", dataPath);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the InputData MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="dataPath">Input argument #1</param>
    /// <param name="index">Input argument #2</param>
    ///
    public void InputData(MWArray dataPath, MWArray index)
    {
      mcr.EvaluateFunction(0, "InputData", dataPath, index);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the InputData MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] InputData(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "InputData", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the InputData MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="dataPath">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] InputData(int numArgsOut, MWArray dataPath)
    {
      return mcr.EvaluateFunction(numArgsOut, "InputData", dataPath);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the InputData MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="dataPath">Input argument #1</param>
    /// <param name="index">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] InputData(int numArgsOut, MWArray dataPath, MWArray index)
    {
      return mcr.EvaluateFunction(numArgsOut, "InputData", dataPath, index);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the Location MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// the_angle1=105.2;
    /// phi_angle1=52.8;
    /// the_angle2=58.7;
    /// phi_angle2=67.8;
    /// the_angle3=151.4;
    /// phi_angle3=62.4;
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Location()
    {
      return mcr.EvaluateFunction("Location", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the Location MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// the_angle1=105.2;
    /// phi_angle1=52.8;
    /// the_angle2=58.7;
    /// phi_angle2=67.8;
    /// the_angle3=151.4;
    /// phi_angle3=62.4;
    /// </remarks>
    /// <param name="data">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Location(MWArray data)
    {
      return mcr.EvaluateFunction("Location", data);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the Location MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// the_angle1=105.2;
    /// phi_angle1=52.8;
    /// the_angle2=58.7;
    /// phi_angle2=67.8;
    /// the_angle3=151.4;
    /// phi_angle3=62.4;
    /// </remarks>
    /// <param name="data">Input argument #1</param>
    /// <param name="p1">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Location(MWArray data, MWArray p1)
    {
      return mcr.EvaluateFunction("Location", data, p1);
    }


    /// <summary>
    /// Provides a single output, 3-input MWArrayinterface to the Location MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// the_angle1=105.2;
    /// phi_angle1=52.8;
    /// the_angle2=58.7;
    /// phi_angle2=67.8;
    /// the_angle3=151.4;
    /// phi_angle3=62.4;
    /// </remarks>
    /// <param name="data">Input argument #1</param>
    /// <param name="p1">Input argument #2</param>
    /// <param name="p2">Input argument #3</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Location(MWArray data, MWArray p1, MWArray p2)
    {
      return mcr.EvaluateFunction("Location", data, p1, p2);
    }


    /// <summary>
    /// Provides a single output, 4-input MWArrayinterface to the Location MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// the_angle1=105.2;
    /// phi_angle1=52.8;
    /// the_angle2=58.7;
    /// phi_angle2=67.8;
    /// the_angle3=151.4;
    /// phi_angle3=62.4;
    /// </remarks>
    /// <param name="data">Input argument #1</param>
    /// <param name="p1">Input argument #2</param>
    /// <param name="p2">Input argument #3</param>
    /// <param name="p3">Input argument #4</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Location(MWArray data, MWArray p1, MWArray p2, MWArray p3)
    {
      return mcr.EvaluateFunction("Location", data, p1, p2, p3);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the Location MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// the_angle1=105.2;
    /// phi_angle1=52.8;
    /// the_angle2=58.7;
    /// phi_angle2=67.8;
    /// the_angle3=151.4;
    /// phi_angle3=62.4;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Location(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Location", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the Location MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// the_angle1=105.2;
    /// phi_angle1=52.8;
    /// the_angle2=58.7;
    /// phi_angle2=67.8;
    /// the_angle3=151.4;
    /// phi_angle3=62.4;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="data">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Location(int numArgsOut, MWArray data)
    {
      return mcr.EvaluateFunction(numArgsOut, "Location", data);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the Location MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// the_angle1=105.2;
    /// phi_angle1=52.8;
    /// the_angle2=58.7;
    /// phi_angle2=67.8;
    /// the_angle3=151.4;
    /// phi_angle3=62.4;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="data">Input argument #1</param>
    /// <param name="p1">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Location(int numArgsOut, MWArray data, MWArray p1)
    {
      return mcr.EvaluateFunction(numArgsOut, "Location", data, p1);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the Location MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// the_angle1=105.2;
    /// phi_angle1=52.8;
    /// the_angle2=58.7;
    /// phi_angle2=67.8;
    /// the_angle3=151.4;
    /// phi_angle3=62.4;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="data">Input argument #1</param>
    /// <param name="p1">Input argument #2</param>
    /// <param name="p2">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Location(int numArgsOut, MWArray data, MWArray p1, MWArray p2)
    {
      return mcr.EvaluateFunction(numArgsOut, "Location", data, p1, p2);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the Location MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// the_angle1=105.2;
    /// phi_angle1=52.8;
    /// the_angle2=58.7;
    /// phi_angle2=67.8;
    /// the_angle3=151.4;
    /// phi_angle3=62.4;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="data">Input argument #1</param>
    /// <param name="p1">Input argument #2</param>
    /// <param name="p2">Input argument #3</param>
    /// <param name="p3">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Location(int numArgsOut, MWArray data, MWArray p1, MWArray p2, 
                        MWArray p3)
    {
      return mcr.EvaluateFunction(numArgsOut, "Location", data, p1, p2, p3);
    }


    /// <summary>
    /// Provides an interface for the Location function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// the_angle1=105.2;
    /// phi_angle1=52.8;
    /// the_angle2=58.7;
    /// phi_angle2=67.8;
    /// the_angle3=151.4;
    /// phi_angle3=62.4;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void Location(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("Location", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the W4Denoise MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 小波分析
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray W4Denoise()
    {
      return mcr.EvaluateFunction("W4Denoise", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the W4Denoise MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 小波分析
    /// </remarks>
    /// <param name="truesignalN">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray W4Denoise(MWArray truesignalN)
    {
      return mcr.EvaluateFunction("W4Denoise", truesignalN);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the W4Denoise MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 小波分析
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] W4Denoise(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "W4Denoise", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the W4Denoise MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 小波分析
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="truesignalN">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] W4Denoise(int numArgsOut, MWArray truesignalN)
    {
      return mcr.EvaluateFunction(numArgsOut, "W4Denoise", truesignalN);
    }


    /// <summary>
    /// Provides an interface for the W4Denoise function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 小波分析
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void W4Denoise(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("W4Denoise", numArgsOut, ref argsOut, argsIn);
    }



    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
