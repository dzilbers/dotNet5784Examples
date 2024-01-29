namespace Lesson6_CLI;

internal delegate void PrintEventHandler();

internal class Printer
{
    public PrintEventHandler? PageOver = null;
    private int pageCount = 20;
    private void handlePageOver()
                                  //                   { if (PageOver != null) PageOver(); }
                                  => PageOver?.DynamicInvoke(this);
    public void Print(int pages)
    {
        if (pages <= pageCount) pageCount -= pages;
        else { pageCount = 0; handlePageOver(); }
    }
}
