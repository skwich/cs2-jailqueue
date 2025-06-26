namespace JailQueue.Interfaces;

public interface IServerService
{
    /// <summary>
    /// Посчитать количество КТ
    /// </summary>
    /// <returns>Количество КТ</returns>
    public int CountCT();

    /// <summary>
    /// Посчитать количество Т
    /// </summary>
    /// <returns>Количество Т</returns>
    public int CountT();
}