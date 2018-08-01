public interface ICamera
{
    //구현클래스에 대한 인터페이스를 제공한다.
    //실질적인 구현을 제공한 서브클래스들에 공통적인 연산의 시그니처만을 정의한다
    void ZoomInOut(bool isZoom);
    void MovingCamera();
}
