namespace DataApp;

public class DataManager
{
    private DataFetcher _dataFetcher;
    private DataStorage _dataStorage;

    /// <summary>
    /// Call from backup local path if network call is unavailable
    /// </summary>
    private const string LocalSourcePath = "D:\\Github\\data-app\\src\\DataApp";

    public DataManager()
    {
        _dataFetcher = new DataFetcher();
        _dataStorage = new DataStorage();
    }

    /// <summary>
    /// Consolidate the data from the DataFetcher sources into a centralized data store.
    /// </summary>
    /// <returns>-1 if an invalid dataId (less than 0) is provided, -2 if the data fetched from the supplied ID was null or whitespace,
    /// or 0 if we successfully consolidated.
    /// </returns>
    public int ConsolidateDataFromSources(int dataId)
    {
        if (dataId < 0)
        {
            return -1;
        }

        /// Create Mock Data
        string data;

        /// Added Error Handling if external network call to storage fails
        try
        {
            data = _dataFetcher.FetchData(dataId);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Call to External Network Failed: " + ex.Message);
            Console.WriteLine("Using Local Data");
            data = FetchDataFromLocal(dataId);
        }

        if (string.IsNullOrWhiteSpace(data))
        {
            return -2;
        }

        _dataStorage.StoreData(dataId, data);
        return 0;
    }

    private string FetchDataFromLocal(int dataId)
    {
        try
        {
            return File.ReadAllText($"{LocalSourcePath}{dataId}.dat");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "";
        }
    }

    /*
    public int ConsolidateDataFromSources(int dataId)
    {
        if (dataId < 0)
        {
            return -1;
        }

        var data = _dataFetcher.FetchData(dataId);
        if (string.IsNullOrWhiteSpace(data))
        {
            return -2;
        }
        _dataStorage.StoreData(dataId, data);
        return 0;
    }
    */
}
