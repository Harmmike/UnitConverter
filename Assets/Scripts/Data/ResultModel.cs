/// <summary>
/// Class for results of conversions. Requires
/// data to be input as string.
/// </summary>
public class ResultModel
{
    public string Result { get; private set; }

    public ResultModel(string result)
    {
        Result = result;
    }
}
