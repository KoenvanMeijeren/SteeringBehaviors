using System.Drawing;

namespace SteeringCS.grid
{
    public interface IGridRender
    {
        void Render(Graphics graphic);
        void RenderOutline(Graphics graphic);
        void RenderGraph(Graphics graphic);
    }
}
