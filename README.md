# nd-F-Reminder
여름 겜마루 공모전!!
함수들이 참 다양하죠?
ChangeRed.cs
bool r_state
(0이면 red 스위치가 눌리지 않을 것이고, 1이면 red 스위치가눌린 상황을 의미한다)
Sprite r1, r0; 
(존재하는 그림과 존재하지 않는 블럭 그림의 sprite를받아오는 전역 변수)


r_chn이라는 함수는 state값 (이 블록은 존재하는 상태입니까 아니면 안 존재하는 상태입니까를 표현하는 값)
을 받아서spriteRenderer.sprite의 이미지를 바꿉니다.

IsTruetag의 종류에 따라, 해당 물체의 첫 이미지를 결정합니다.
(이렇게 한 이유는 이 script가 '존재'하는 블럭과 '비 존재'하는 블록양쪽에 다 이식되기 때문에 
이게 어느 블럭인지 구분을 하기 위해서 state값을 이식해주기 위함)

SendStatement는 사실 ChangeRed에서 Moving_4에 현 스위치나 칼라의 상황을 전달해주기 위해만든 함수이지만....적어두고 쓰지 않았다;

....이걸 왜 적지

