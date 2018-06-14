# go-prince
![image](./info_img/go_prince_img1.png)
![image](./info_img/go_prince_img2.png)

## 소개
`악당들을 물리치고 공주를 구하러 가는 왕자가 주인공인 Unity 게임`입니다.

## 개발환경
![image](./info_img/unity.jpg)

## 개발인원
개발 2명([권현아](https://github.com/kwonhyeona), [고민주](https://github.com/minju54))

## 주요기능
* MVC패턴 기반으로 파일 생성 및 코드 구현
* 컴포넌트 기반으로 오브젝트 제어 및 코드 구현
* Unity의 생명주기 활용
* rigidbody를 이용한 충돌 구현
* 적과 왕자가 서로를 추적
* 카메라 제어

## 주요코드
```csharp
// 생명주기인 Start 에서 오브젝트의 컴포넌트를 저장합니다.
void Start () {
    ...
    badGuyTr = this.gameObject.GetComponent<Transform>();
    ...
}
```

```csharp
/*
    충돌 처리 코드입니다.
    충돌이 일어나면 OnCollisionEnter -> OnCollisionStay -> OnCollisionExit 이 트리거됩니다.
    오브젝트를 제거하는 방법은 Destroy(object)입니다.
*/
void OnCollisionEnter(Collision coll) {
     if(coll.collider.tag == "SNOW") {
        Debug.Log("SNOW와 충돌했습니다.");
        Destroy(coll.gameObject); // 층돌한 눈덩이 제거
        if (++hitCount >= 3) ChangeGauge();
    }
}
```

```csharp
/*
    unity의 생명주기 중 하나인 update는 FPS가 60이라면 1초당 60번 프레임이 그려질 때마다 호출되는 함수입니다.
    update의 호출 주기를 수정할 수 없으며 다양한 요인으로 조정됩니다.
    따라서 내가 원하는 호출 주기를 정하고 싶다면 StartCoroutine() 함수를 사용해야 합니다.
*/
void Start () {
    ...
    StartCoroutine(this.CheckBadGuyState());
    ...
}

IEnumerator CheckBadGuyState() {
    while(!isDie) {
        yield return new WaitForSeconds(0.2f);
        ...
    }
}
```

```csharp
// Vector3.Lerp() 를 이용해 카메라를 제어했습니다.
void Update () {
    secondCameraTr.position = Vector3.Lerp(secondCameraTr.position,
                                princeTR.position - (princeTR.forward * dist) + (Vector3.up * height ),
                                Time.deltaTime * dampTrace);
    secondCameraTr.LookAt(princeTR.position);
}
```
