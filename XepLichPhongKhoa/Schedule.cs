using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace XepLichPhongKhoa
{
    class Schedule
    {
        public tblRoom[] arR { get; set; }
        public tblCourse[] arC;
        public RoomStatus[,] ScheArr;
        public DateTime dateStart = new DateTime();
        public DateTime maxDateEnd = new DateTime(3000, 1, 1);
        public int[] a;
        public CourseDAL bllcourse = new CourseDAL();
        public CalendarDAL bllCal = new CalendarDAL();
        public Schedule(DataTable dtR, DataTable dtC)
        {

            int i = 0;
            arR = new tblRoom[dtR.Rows.Count];
            foreach (DataRow row in dtR.Rows)
            {
                if (!string.IsNullOrEmpty(row[0].ToString()))
                {
                    arR[i] = new tblRoom();
                    arR[i].IDRoom = row[0].ToString();
                    arR[i].Maxsize = (int)row[1];
                    i++;
                }
            }
            i = 0;
            arC = new tblCourse[dtC.Rows.Count];
            a = new int[dtC.Rows.Count];
            foreach (DataRow row in dtC.Rows)
            {
                if (!string.IsNullOrEmpty(row[0].ToString()))
                {
                    arC[i] = new tblCourse();
                    arC[i].IDCourse = row[0].ToString();
                    arC[i].NameCourse = row[1].ToString();
                    DateTime temp = new DateTime();
                    temp = DateTime.Parse(row[2].ToString());
                    arC[i].DateBegin = temp.Date;
                    if (!string.IsNullOrEmpty(row[3].ToString()))
                    {
                        temp = DateTime.Parse(row[3].ToString());
                        arC[i].DateEnd = temp.Date;
                    }
                    arC[i].AvbNumber = (int)row[4];
                    if (row[5].ToString() == "True")
                    {
                        arC[i].OpenStatus = true;
                    }
                    else arC[i].OpenStatus = false;
                    //if (row[6].ToString() == "True")
                    //{
                    //    arC[i].EndStatus = true;
                    //}
                    //else 
                    arC[i].EndStatus = false;
                    arC[i].SchoolDayType = row[6].ToString();
                    arC[i].NoSW = (int)row[7];
                    i++;
                }
            }
        }
        public int getLengthR()
        {
            int n = 0;
            foreach (tblRoom r in arR)
            {
                n++;
            }
            return n;
        }
        public int getLengthC()
        {
            int n = 0;
            foreach (tblCourse r in arC)
            {
                n++;
            }
            return n;
        }
        public void SortRoomBySize()
        {
            for (int i = 0; i < this.getLengthR() - 1; i++)
            {
                for (int j = i + 1; j < this.getLengthR(); j++)
                {
                    if (arR[i].Maxsize > arR[j].Maxsize)
                    {
                        tblRoom temp = new tblRoom();
                        temp = arR[i];
                        arR[i] = arR[j];
                        arR[j] = temp;
                    }
                }
            }
        }
        public void SortCourseByDateBegin()
        {
            for (int i = 0; i < this.getLengthC() - 1; i++)
            {
                for (int j = i + 1; j < this.getLengthC(); j++)
                {
                    if (arC[i].DateBegin > arC[j].DateBegin)
                    {
                        tblCourse temp = new tblCourse();
                        temp = arC[i];
                        arC[i] = arC[j];
                        arC[j] = temp;
                    }
                    if (arC[i].DateBegin == arC[j].DateBegin && arC[i].AvbNumber > arC[j].AvbNumber)
                    {
                        tblCourse temp = new tblCourse();
                        temp = arC[i];
                        arC[i] = arC[j];
                        arC[j] = temp;
                    }
                }
            }
        }
        private DateTime getMinDateBegin()
        {
            DateTime minDate = arC[0].DateBegin;
            for (int i = 1; i < this.getLengthC(); i++)
            {
                if (arC[i].DateBegin < minDate)
                    minDate = arC[i].DateBegin;
            }
            return minDate;
        }
        private DateTime getMaxDateEnd()
        {
            DateTime maxDate = arC[0].DateBegin.AddDays(arC[0].NoSW * 7);
            for (int i = 1; i < getLengthC(); i++)
            {
                if (maxDate < arC[i].DateBegin.AddDays(arC[i].NoSW * 7))
                {
                    maxDate = arC[i].DateBegin.AddDays(arC[i].NoSW * 7);
                }
            }
            return maxDate;

        }
        private DateTime MondayOfWeek(DateTime date)
        {
            var dateOfWeek = date.DayOfWeek;
            if (dateOfWeek == DayOfWeek.Monday)
            {
                return date;
            }
            if (dateOfWeek == DayOfWeek.Tuesday && getSchoolDayType(arC[0].SchoolDayType) == 2)
                return date.AddDays(-1);
            return date.AddDays(DayOfWeek.Sunday - dateOfWeek + 1);
        }
        private int getSchoolDayType(string str)
        {
            if (str == "2, 4, 6") return 1;
            if (str == "3, 5, 7") return 2;
            return 3;
        }
        private void SortCourseByAvbNumber()
        {
            for (int i = 0; i < this.getLengthC() - 1; i++)
            {
                for (int j = i + 1; j < this.getLengthC(); j++)
                {
                    if (arC[i].AvbNumber > arC[j].AvbNumber)
                    {
                        tblCourse temp = new tblCourse();
                        temp = arC[i];
                        arC[i] = arC[j];
                        arC[j] = temp;
                    }
                }
            }
        }
        private void UpdateCalendar(RoomStatus[,] rs)
        {
            if (!bllCal.DeleteCalendar()) return;
            else { bool kt = bllCal.DeleteCalendar(); }
            DateTime temp = dateStart;
            for (int i = 0; i < rs.GetLength(1); i++)
            {
                for (int j = 0; j < rs.GetLength(0); j++)
                {
                    if (!string.IsNullOrEmpty(rs[j, i].NC246))
                    {
                        tblCalendar ct = new tblCalendar();
                        ct.DateOf = temp;
                        ct.IDRoom = arR[j].IDRoom;
                        ct.IDCourse = rs[j, i].NC246;
                        bllCal.InsertCalendar(ct);
                        ct.DateOf = ct.DateOf.AddDays(2);
                        bllCal.InsertCalendar(ct);
                        ct.DateOf = ct.DateOf.AddDays(2);
                        bllCal.InsertCalendar(ct);
                    }
                    if (!string.IsNullOrEmpty(rs[j, i].NC357))
                    {
                        tblCalendar ct = new tblCalendar();
                        ct.DateOf = temp.AddDays(1);
                        ct.IDRoom = arR[j].IDRoom;
                        ct.IDCourse = rs[j, i].NC357;
                        bllCal.InsertCalendar(ct);
                        ct.DateOf = ct.DateOf.AddDays(2);
                        bllCal.InsertCalendar(ct);
                        ct.DateOf = ct.DateOf.AddDays(2);
                        bllCal.InsertCalendar(ct);
                    }
                    if (!string.IsNullOrEmpty(rs[j, i].NCCN))
                    {
                        tblCalendar ct = new tblCalendar();
                        ct.DateOf = temp.AddDays(6);
                        ct.IDRoom = arR[j].IDRoom;
                        ct.IDCourse = rs[j, i].NCCN;
                        bllCal.InsertCalendar(ct);
                    }
                }
                temp = temp.AddDays(7);
            }
        }
        #region
        private bool CheckArr(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public tblCourse[] getArrangeCourse(int[] ar)
        {
            tblCourse[] temp = new tblCourse[ar.Length];
            for (int i = 0; i < ar.Length; i++)
            {
                temp[ar[i]] = new tblCourse();
                temp[ar[i]] = arC[i];
            }
            return temp;
        }
        void BF(int k)
        {
            if (k == arC.Length) return;
            for (int i = 0; i < getLengthC(); i++)
            {
                a[k] = i;
                if (k == (a.Length - 1) && CheckArr(a) == true)
                {
                    tblCourse[] tempCourse = getArrangeCourse(a);
                    RoomStatus[,] arr = new RoomStatus[0, 0];
                    if (Sche(tempCourse, ref arr) < maxDateEnd)
                    {
                        ScheArr = arr;
                        maxDateEnd = Sche(tempCourse, ref arr);
                    }
                }
                else BF(k + 1);
            }
        }
        public DateTime Sche(tblCourse[] course, ref RoomStatus[,] temparr)
        {
            CultureInfo viVn = new CultureInfo("vi-VN");
            dateStart = MondayOfWeek(getMinDateBegin());
            DateTime dateTemp = dateStart;
            //dateStart = dateStart.AddDays(7);
            SortRoomBySize();
            SortCourseByDateBegin();
            TimeSpan span = getMaxDateEnd().Subtract(dateStart);
            int n = span.Days / 7;
            n *= 2;
            int m = getLengthR();
            DateTime dateEnd = dateTemp;
            RoomStatus[,] sche = new RoomStatus[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sche[i, j] = new RoomStatus();
                }
            }
            for (int i = 0; i < n; i++)//////////Xét mỗi tuần                             
            {
                for (int u = 0; u < getLengthC(); u++)/////////Xét mỗi khóa học
                {
                    if ((course[u].DateBegin <= dateTemp) && (course[u].OpenStatus = true) && (course[u].NoSW > 0) && (course[u].EndStatus == false))/////////Tìm ra những khóa đã đến ngày mở
                    {
                        int[] t = new int[3];
                        bool checkedCourse = false;
                        for (int x = 0; x < 3; x++)
                        {
                            t[x] = -1;
                        }
                        for (int k = 0; k < m; k++)/////////Tìm phòng để sắp vào
                        {
                            switch (getSchoolDayType(course[u].SchoolDayType))
                            {
                                case 1: if (course[u].AvbNumber <= arR[k].Maxsize)
                                    {
                                        if (sche[k, i].th246 == false)
                                        {
                                            sche[k, i].th246 = true;
                                            sche[k, i].NC246 = course[u].IDCourse;
                                            course[u].NoSW -= 1;
                                            checkedCourse = true;
                                            if (course[u].NoSW == 0)
                                            {
                                                course[u].EndStatus = true;
                                                course[u].DateEnd = dateTemp.Date.AddDays(4);
                                                dateEnd = dateTemp.Date.AddDays(4);
                                                bllcourse.UpdateDateEndCourse(course[u]);
                                            }
                                        }
                                    }
                                    break;
                                case 2: if (course[u].AvbNumber <= arR[k].Maxsize)
                                    {
                                        if (sche[k, i].th357 == false)
                                        {
                                            sche[k, i].th357 = true;
                                            sche[k, i].NC357 = course[u].IDCourse;
                                            course[u].NoSW -= 1;
                                            checkedCourse = true;
                                            if (course[u].NoSW == 0)
                                            {
                                                course[u].EndStatus = true;
                                                course[u].DateEnd = dateTemp.Date.AddDays(5);
                                                dateEnd = dateTemp.Date.AddDays(5);
                                                bllcourse.UpdateDateEndCourse(course[u]);
                                            }
                                        }
                                    }
                                    break;
                                case 3:
                                    if (course[u].AvbNumber <= arR[k].Maxsize && t[0] == -1)
                                    {
                                        if (sche[k, i].th246 == false)
                                        {
                                            t[0] = k;
                                        }
                                    }
                                    if (course[u].AvbNumber <= arR[k].Maxsize && t[1] == -1)
                                    {
                                        if (sche[k, i].th357 == false)
                                        {
                                            t[1] = k;
                                        }
                                    }
                                    if (course[u].AvbNumber <= arR[k].Maxsize && t[2] == -1)
                                    {
                                        if (sche[k, i].cn == false)
                                        {
                                            t[2] = k;
                                        }
                                    }
                                    bool kt = true;
                                    for (int x = 0; x < 3; x++)
                                    {
                                        if (t[x] == -1)
                                        {
                                            kt = false;
                                            break;
                                        }

                                    }
                                    if (kt == true)
                                    {
                                        sche[t[0], i].th246 = true;
                                        sche[t[0], i].NC246 = course[u].IDCourse;
                                        sche[t[1], i].th357 = true;
                                        sche[t[1], i].NC357 = course[u].IDCourse;
                                        sche[t[2], i].cn = true;
                                        sche[t[2], i].NCCN = course[u].IDCourse;
                                        checkedCourse = true;
                                        course[u].NoSW -= 1;
                                        if (course[u].NoSW == 0)
                                        {
                                            course[u].EndStatus = true;
                                            course[u].DateEnd = dateTemp.Date.AddDays(6);
                                            dateEnd = dateTemp.Date.AddDays(6);
                                            bllcourse.UpdateDateEndCourse(course[u]);
                                        }
                                    }
                                    break;
                            }
                            if (checkedCourse == true) break;
                        }
                    }
                }
                dateTemp = dateTemp.AddDays(7);
            }
            temparr = sche;
            return dateEnd;
        }
        #endregion
        private void SortCourseByNoSW(int k)
        {
            for (int i = 0; i < this.getLengthC() - 1; i++)
            {
                for (int j = i + 1; j < this.getLengthC(); j++)
                {
                    if (arC[i].NoSW <= arC[j].NoSW && k == 0)
                    {
                        tblCourse temp = new tblCourse();
                        temp = arC[i];
                        arC[i] = arC[j];
                        arC[j] = temp;
                    }
                    if (arC[i].NoSW >= arC[j].NoSW && k == 1)
                    {
                        tblCourse temp = new tblCourse();
                        temp = arC[i];
                        arC[i] = arC[j];
                        arC[j] = temp;
                    }
                }
            }
        }
        public RoomStatus[,] SolveSchedule(int st)
        {
            ///////////
            //CultureInfo viVn = new CultureInfo("vi-VN");
            //dateStart = MondayOfWeek(getMinDateBegin());
            //BF(0);
            //return ScheArr;
            ////////////////
            ///
            CultureInfo viVn = new CultureInfo("vi-VN");
            dateStart = MondayOfWeek(getMinDateBegin());
            DateTime dateTemp = dateStart;
            //dateStart = dateStart.AddDays(7);

            SortRoomBySize();
            SortCourseByDateBegin();
            TimeSpan span = getMaxDateEnd().Subtract(dateStart);
            int n = span.Days / 7;
            n *= 2;
            int m = getLengthR();
            RoomStatus[,] sche = new RoomStatus[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sche[i, j] = new RoomStatus();
                }
            }

            SortCourseByAvbNumber();
            for (int i = 0; i < n; i++)//////////Xét mỗi tuần                             
            {
                ///
                if (st == 0) SortCourseByNoSW(0);
                else if(st == 1)SortCourseByNoSW(1);
                    ///
                for (int u = 0; u < getLengthC(); u++)/////////Xét mỗi khóa học
                {
                    if ((arC[u].DateBegin <= dateTemp) && (arC[u].OpenStatus = true) && (arC[u].NoSW > 0) && (arC[u].EndStatus == false))/////////Tìm ra những khóa đã đến ngày mở
                    {
                        int[] t = new int[3];
                        bool checkedCourse = false;
                        for (int x = 0; x < 3; x++)
                        {
                            t[x] = -1;
                        }
                        for (int k = 0; k < m; k++)/////////Tìm phòng để sắp vào
                        {
                            switch (getSchoolDayType(arC[u].SchoolDayType))
                            {
                                case 1: if (arC[u].AvbNumber <= arR[k].Maxsize)
                                    {
                                        if (sche[k, i].th246 == false)
                                        {
                                            sche[k, i].th246 = true;
                                            sche[k, i].NC246 = arC[u].IDCourse;
                                            arC[u].NoSW -= 1;
                                            checkedCourse = true;
                                            if (arC[u].NoSW == 0)
                                            {
                                                arC[u].EndStatus = true;
                                                arC[u].DateEnd = dateTemp.Date.AddDays(4);
                                                bllcourse.UpdateDateEndCourse(arC[u]);
                                            }
                                        }
                                    }
                                    break;
                                case 2: if (arC[u].AvbNumber <= arR[k].Maxsize)
                                    {
                                        if (sche[k, i].th357 == false)
                                        {
                                            sche[k, i].th357 = true;
                                            sche[k, i].NC357 = arC[u].IDCourse;
                                            arC[u].NoSW -= 1;
                                            checkedCourse = true;
                                            if (arC[u].NoSW == 0)
                                            {
                                                arC[u].EndStatus = true;
                                                arC[u].DateEnd = dateTemp.Date.AddDays(5);
                                                bllcourse.UpdateDateEndCourse(arC[u]);
                                            }
                                        }
                                    }
                                    break;
                                case 3:
                                    if (arC[u].AvbNumber <= arR[k].Maxsize && t[0] == -1)
                                    {
                                        if (sche[k, i].th246 == false)
                                        {
                                            t[0] = k;
                                        }
                                    }
                                    if (arC[u].AvbNumber <= arR[k].Maxsize && t[1] == -1)
                                    {
                                        if (sche[k, i].th357 == false)
                                        {
                                            t[1] = k;
                                        }
                                    }
                                    if (arC[u].AvbNumber <= arR[k].Maxsize && t[2] == -1)
                                    {
                                        if (sche[k, i].cn == false)
                                        {
                                            t[2] = k;
                                        }
                                    }
                                    bool kt = true;
                                    for (int x = 0; x < 3; x++)
                                    {
                                        if (t[x] == -1)
                                        {
                                            kt = false;
                                            break;
                                        }

                                    }
                                    if (kt == true)
                                    {
                                        sche[t[0], i].th246 = true;
                                        sche[t[0], i].NC246 = arC[u].IDCourse;
                                        sche[t[1], i].th357 = true;
                                        sche[t[1], i].NC357 = arC[u].IDCourse;
                                        sche[t[2], i].cn = true;
                                        sche[t[2], i].NCCN = arC[u].IDCourse;
                                        checkedCourse = true;
                                        arC[u].NoSW -= 1;
                                        if (arC[u].NoSW == 0)
                                        {
                                            arC[u].EndStatus = true;
                                            arC[u].DateEnd = dateTemp.Date.AddDays(6);
                                            bllcourse.UpdateDateEndCourse(arC[u]);
                                        }
                                    }
                                    break;
                            }
                            if (checkedCourse == true) break;
                        }
                    }
                }
                dateTemp = dateTemp.AddDays(7);
            }
            //Cập nhập lại những khóa chưa sắp lịch được và ngày kết thúc
            for (int u = 0; u < getLengthC(); u++)
            {
                if (arC[u].EndStatus == false)
                {
                    arC[u].DateEnd = new DateTime(2000, 1, 1);
                    bllcourse.UpdateDateEndCourse(arC[u]);
                }
            }
            //UPdate Lịch
            UpdateCalendar(sche);
            return sche;
        }
    }
}
