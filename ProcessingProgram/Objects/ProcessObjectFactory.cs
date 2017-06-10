using System.Collections.Generic;
using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices.Filters;

namespace ProcessingProgram.Objects
{
    public static class ProcessObjectFactory
    {
        private static List<ProcessObject> _processObjects;
        private static List<ProcessCurve> _processCurves;
        //private static ProcessingParams _processingParams;
        private static int _no;

        public static void Init(List<ProcessObject> processObjects, List<ProcessCurve> processCurves)
        {
            _processObjects = processObjects;
            _processCurves = processCurves;
        }

        /// <summary>
        /// ������� �������������� �������
        /// </summary>
        /// <param name="dbObjects">������ ��������</param>
        /// <param name="tools">�����������</param>
        public static void Create(List<DBObject> dbObjects, IEnumerable<Tool> tools)
        {
            foreach (var tool in tools.OrderBy(p => p.OrderNo))
            {
//                ProcessObject prevProcessObject = null;

                foreach (var dbObject in dbObjects)
                {
                    if (((Entity)dbObject).Layer != "0" && ((Entity)dbObject).Layer != "������")
                    {
                        AutocadUtils.ShowError("������ �� � ���� \"0\" ��� \"������\"");
                        continue;
                    }
                    if (!(dbObject is Line) && !(dbObject is Arc) && !(dbObject is Polyline) &&
                        !(dbObject is Polyline2d) && !(dbObject is Circle))
                    {
                        AutocadUtils.ShowError("���������������� ��� ������: " + dbObject);
                        continue;
                    }
                    //obj.Modified += new EventHandler(ProcessCurveModifiedEventHandler);
                    //obj.Erased += new ObjectErasedEventHandler(ProcessCurveErasedEventHandler);

                    var curve = _processCurves.FirstOrDefault(p => p.ObjectId == dbObject.ObjectId);
                    if (curve == null)
                    {
                        curve = new ProcessCurve(dbObject as Curve, ++_no);
                        _processCurves.Add(curve);
                    }
                    var processObject = new ProcessObject(curve, tool);
                    _processObjects.Add(processObject);

// TODO ������ ��� ���������� ��������

/*                        if (prevProcessObject != null && ProcessingParams.GetDefault().DepthAll == 0)
                    {
                        if (curve.StartPoint != prevProcessObject.Curve.StartPoint && curve.StartPoint != prevProcessObject.Curve.EndPoint)
                        {
                            if (curve.EndPoint != prevProcessObject.Curve.StartPoint && curve.EndPoint != prevProcessObject.Curve.EndPoint)
                                prevProcessObject = null;
                            else
                                processObject.ReverseProcess();
                        }

                        if (prevProcessObject != null)
                        {
                            prevProcessObject.ProcessingParams.RetractionType = "���";
                            processObject.ProcessingParams.FeedType = "���";
                        }
                    }
                    prevProcessObject = processObject;*/
                }
            }
        }
    }
}
