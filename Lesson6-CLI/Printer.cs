namespace Lesson6_CLI;

//internal delegate void PrintEventHandler();

internal class PrinterEventArgs : EventArgs
{
    public int NotPrinted { get; init; }
    public bool Done { get; set; } = false;
    
    public PrinterEventArgs(int notPrinted) => NotPrinted = notPrinted;    
}

internal class Printer
{
    //public event PrintEventHandler? PageOver = null;
    public event EventHandler<PrinterEventArgs>? PageOver = null;
    private int _pageCount = 20;
    private void handlePageOver(int count)
    { if (PageOver != null) PageOver(this, new PrinterEventArgs(count)); }
                                //  => PageOver?.DynamicInvoke();
    public void Print(int pages)
    {
        if (pages <= _pageCount) _pageCount -= pages;
        else 
        {
            handlePageOver(pages - _pageCount);
            _pageCount = 0; 
        }
    }
}
