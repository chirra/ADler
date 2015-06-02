using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ADler.ViewModel
{
    public class DrawingCanvas : Canvas
    {
        // Коллекция уже нарисованных квадратов.
        private List<Visual> visuals = new List<Visual>();

        // Панель будет использовать этот метод для доступа к каждому элементу, который надо визуализировать.
        protected override Visual GetVisualChild(int index)
        {
            return visuals[index];
        }

        // Получение общего количества элементов для визуализации.
        protected override int VisualChildrenCount
        {
            get
            {
                return visuals.Count;
            }
        }

        public void AddVisual(Visual visual)
        {
            visuals.Add(visual);

            // Эти методы нужны для того, что бы корректно работали функции  взаимодействия элементов,
            // например, такие как проверка попадания курсора в элемент.
            base.AddVisualChild(visual);
            base.AddLogicalChild(visual);
        }

        public void DeleteVisual(Visual visual)
        {
            visuals.Remove(visual);
            base.RemoveVisualChild(visual);
            base.RemoveLogicalChild(visual);
        }

        // Метод для проверки попадания.
        public DrawingVisual GetVisual(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
            return hitResult.VisualHit as DrawingVisual;
        }

        private List<DrawingVisual> hits = new List<DrawingVisual>();
        public List<DrawingVisual> GetVisuals(Geometry region)
        {
            hits.Clear(); // Очищение коллекции результатов проверки попадания.
            GeometryHitTestParameters parameters = new GeometryHitTestParameters(region);
            HitTestResultCallback callback = new HitTestResultCallback(this.HitTestCallback); // Метод обратного вызова.
            VisualTreeHelper.HitTest(this, null, callback, parameters);
            return hits;
        }

        // Метод, который будет находить элементы попавшие в регион.
        private HitTestResultBehavior HitTestCallback(HitTestResult result)
        {
            GeometryHitTestResult geometryResult = (GeometryHitTestResult)result;
            DrawingVisual visual = result.VisualHit as DrawingVisual;
            if (visual != null &&
                geometryResult.IntersectionDetail == IntersectionDetail.FullyInside)
            {
                hits.Add(visual);
            }
            return HitTestResultBehavior.Continue;
        }
    }

}
