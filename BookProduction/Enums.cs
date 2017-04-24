using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookProduction;
using BookProduction.BookComponents;
using BookProduction.Assembly;
using BookProduction.IssueParams;
using BookProduction.Paper;
using BookProduction.PriceLists;
using BookProduction.PrintingPresses;
using BookProduction.Tasks;
using BookProduction.TypographyManagement;

namespace BookProduction
{

    public enum PaperType //типы бумаги
    {
        Newsprint, //газетка
        Offset,//офсет
        CoatedPaper,//меловка
        FoldingBoxboard,//хром-эрзац
        Cardboard,//картон 
        SelfAdhensivePaper, //самоклейка
        CardboardAliaska//Картон Аляска
    }

    public enum PaperUnit //единицы измерения бумаги
    {
        kg,//килограммы
        sheet//лист
    }


    public enum BindingType //типы переплета
    {
        SaddleStitching,//cкоба
        PerfectBinding,//клеевой
        HardcoverBinding//7БЦ
    }

    public enum LaminationType //типы ламинации
    {
        withoutLamination,// без ламинации
        Glossy,//глянцевая ламинация
        Matte//матовая ламинация
    }

    public enum PerforationType
    {
        withoutPerforation,//без перфорации
        usual,//обычная
        simplified//упрощенная
    }

    public enum PaperFormat //форматы бумаги для ламинации
    {
        A1,
        A2,
        A3,
        A4
    }


    public enum IssueFormatType
    {
        f60x90_1,//new
        f60x90_2,//new
        f60x90_8,
        f60x90_16,
        f70x100_16,//new
        f84x108_16
    }

    public enum PaperFullType
    {
        Newsprint_45,
        Offset_60,
        Offset_80,
        Offset_120,//new
        CoatedPaper_120,//new
        FoldingBoxboard_230,
        CardboardAliaska_230//new

    }

    public enum ColorsType
    {
        c1_1,
        c2_2,
        c4_0,
        c4_1,
        c4_4
    }
}
