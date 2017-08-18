# nd-F-Reminder
여름 겜마루 공모전!!
일단 sprite 파일에 블록과 스위치 이미지 추가했습니다.
Moving_4에서 스위치의 상부 trigger와 겹치면
SwitchAction이라는 코드에서 이미지를 바꾸는 형식인데
둘 사이를 연결해 주는 것이 r값 입니다. 
즉,Moving_4에서 '붉은'이미지를 지닌 스위치를 누르면 r값이 호출되여
SwitchAction.Press()라는 함수에 값이 들어갑니다.
그러면 SwitchAction에서 r을 입력받아 뭐..이미지를 바꾸는 방식;;

그런데 문제는 r 값은 받는데 이미지를 변경하는 방법이 안 보여요; 허허허허허허
