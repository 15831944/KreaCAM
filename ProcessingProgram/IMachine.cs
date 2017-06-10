using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using ProcessingProgram.Constants;
using ProcessingProgram.Objects;
using System;

namespace ProcessingProgram
{
    /// <summary>
    /// ��������� ������ ����������� ������ ��������� �������� ������
    /// </summary>
    public interface IMachine
    {
        event EventHandler<EventArgs<int>> ChangeActionsCount;

        /// <summary>
        /// �������� ������������������ �������� ������
        /// </summary>
        /// <returns>������������������ ��������</returns>
        List<ProcessingAction> GetProcessingActions();

        /// <summary>
        /// ���� ������
        /// </summary>
        void Start();

        /// <summary>
        /// ������� ������
        /// </summary>
        void Stop();

        /// <summary>
        /// ������� ���������
        /// </summary>
        void Clear();

        /// <summary>
        /// ���������� �����������
        /// </summary>
        /// <param name="compensation">������� �����������</param>
        void SetCompensation(CompensationSide compensation);

        /// <summary>
        /// ��������� 
        /// </summary>
        /// <param name="path">���������� ���������</param>
        ProcessingAction Cutting(Curve path);

        /// <summary>
        /// ��������� 
        /// </summary>
        /// <param name="pathsList">������ ���������� ���������</param>
        List<ProcessingAction> Cutting(List<Curve> pathsList);

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="path">���������� �������</param>
        void EngageMove(Curve path);

        /// <summary>
        /// �����
        /// </summary>
        /// <param name="path">���������� ������</param>
        void RetractMove(Curve path);

        /// <summary>
        /// ����������� ����������
        /// </summary>
        /// <param name="position">�������</param>
        void Move(Point3d position);

        /// <summary>
        /// ���������� ����������
        /// </summary>
        /// <param name="tool">����������</param>
        void SetTool(Tool tool);

        /// <summary>
        /// ���������� ������
        /// </summary>
        /// <param name="speed">�������� ������</param>
        void SetSpeed(int speed);

        /// <summary>
        /// ���������� ���������� � �������
        /// </summary>
        /// <param name="position">�������</param>
        /// <param name="speed">������</param>
        void SetPosition(Point3d position, int speed);
    }
}