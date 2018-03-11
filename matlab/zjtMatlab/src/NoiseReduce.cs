/*
* MATLAB Compiler: 4.18.1 (R2013a)
* Date: Sat Mar 10 19:32:27 2018
* Arguments: "-B" "macro_default" "-W" "dotnet:zjtMatlab,NoiseReduce,4.0,private" "-T"
* "link:lib" "-d" "G:\zhangjiantaoPro\matlab\zjtMatlab\src" "-w"
* "enable:specified_file_mismatch" "-w" "enable:repeated_file" "-w"
* "enable:switch_ignored" "-w" "enable:missing_lib_sentinel" "-w" "enable:demo_license"
* "-v"
* "class{NoiseReduce:C:\Users\liuxiaochang\Desktop\程序1\程序\去噪\DoubleDataExp.m,C:\User
* s\liuxiaochang\Desktop\程序1\程序\去噪\W4Denoise.m}" 
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
  /// C:\Users\liuxiaochang\Desktop\程序1\程序\去噪\DoubleDataExp.m
  /// <newpara></newpara>
  /// C:\Users\liuxiaochang\Desktop\程序1\程序\去噪\W4Denoise.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 4.0
  /// </remarks>
  public class NoiseReduce : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
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
    /// Provides a single output, 0-input MWArrayinterface to the DoubleDataExp MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// truesignalN = real(XMAT(8,1:T));
    /// denoised = W4Denoise(truesignalN);
    /// plot(tt,denoised)
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
    /// truesignalN = real(XMAT(8,1:T));
    /// denoised = W4Denoise(truesignalN);
    /// plot(tt,denoised)
    /// </remarks>
    /// <param name="dataPath">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DoubleDataExp(MWArray dataPath)
    {
      return mcr.EvaluateFunction("DoubleDataExp", dataPath);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the DoubleDataExp MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// truesignalN = real(XMAT(8,1:T));
    /// denoised = W4Denoise(truesignalN);
    /// plot(tt,denoised)
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
    /// truesignalN = real(XMAT(8,1:T));
    /// denoised = W4Denoise(truesignalN);
    /// plot(tt,denoised)
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
    /// Provides an interface for the DoubleDataExp function in which the input and
    /// output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// truesignalN = real(XMAT(8,1:T));
    /// denoised = W4Denoise(truesignalN);
    /// plot(tt,denoised)
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
