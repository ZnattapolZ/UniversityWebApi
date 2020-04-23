วิธีการใช้งาน UniversityWebApi

เมื่อทำการ  Run project ด้วย shortcut Ctrl+F5 ตัว program จะทำการสร้าง local database ชื่อ UniversityDB 
เพิ่ม sample data ลงไปใน database เเละทำการเปิด web browser ด้วย URL : https://localhost:44306/universities โดยอัตโนมัติ

การใช้งานหรือการทดสอบ API ให้ทดสอบผ่านโปรเเกรม Postman

1.) เมื่อใช้  method GET เเละใส่ URL : https://localhost:44306/universities ใน Postman เเละทำการกด Send ตัว API 
จะ return ข้อมูลของมหาวิทยาลัยทั้งหมดที่อยู่ใน database ในรูปแบบของ JSON
ตัวอย่าง JSON ที่ return กลับมาจาก API (เฉพาะข้อมูลจาก sample data)
[
    {
        "universityId": 1,
        "name": "MU"
    },
    {
        "universityId": 2,
        "name": "CU"
    },
    {
        "universityId": 3,
        "name": "KMUTT"
    }
]

2.) เมื่อใช้  method GET เเละใส่ URL : https://localhost:44306/universities/:id ใน Postman เมื่อทำการกด Send ตัว API
จะทำการ return ข้อมูลของมหาวิทยาลัยที่มี id ตรงกับใน database พร้อมทั้งรายชื่อของนักศึกษาที่ศึกษาอยู่ทั้งหมดในรูปแบบของ JSON
ตัวอย่าง JSON ที่ return กลับมาจาก API เมื่อใช้ method GET เเละ URL : https://localhost:44306/universities/1 (เฉพาะข้อมูลจาก sample data)
[
    {
        "universityId": 1,
        "name": "MU",
        "students": [
            {
                "studentId": 6013110,
                "firstName": "Annie",
                "lastName": "Ant",
                "degree": "Bachelor"
            },
            {
                "studentId": 6013111,
                "firstName": "Brownie",
                "lastName": "Bee",
                "degree": "Bachelor"
            }
        ]
    }
]

3.) เมื่อใช้  method POST เเละใส่ URL : https://localhost:44306/universities ใน Postman จะเป็นการเพิ่มข้อมูลของมหาวิทยาลัยเข้าไปใน database
โดยจะต้องทำการใส่ข้อมูลที่ต้องการเพิ่มในรูปแบบของ JSON ใน Postman ก่อน โดยการเลือก  Body ใต้ช่อง URL เลือก raw เเละเปลี่ยน Text ให้เป็น JSON เเละใส่ข้อมูลที่ต้องการเพิ่ม
ตัวอย่างข้อมูลในรูปแบบ JSON ที่ใช้ในการเพิ่มข้อมูลมหาวิทยาลัย
{
	"universityId": 4,
	"name": "KU"
}

เมื่อกด Send ก็จะเป็นการเพิ่มข้อมูลลงใน database

4.) เมื่อใช้  method PUT เเละใส่ URL : https://localhost:44306/universities/:id ใน Postman จะเป็นการเเก้ไขข้อมูลของมหาวิทยาลัยที่มี id 
ตรงกับใน database โดยจะต้องทำการใส่ข้อมูลที่ต้องการจะเเก้ไขก่อนกด Send โดยข้อมูลดังกล่าวจะต้องเป็นข้อมูลในรูปแบบ JSON วิธีการใส่ข้อมูลที่ต้องการเเก้ไขจะทำเช่นเดียวกันกับในข้อ 3.
ตัวอย่างการเเก้ไขข้อมูลมหาวิทยาลัยที่มี id เท่ากับ 4 ใน database ใช้ method PUT เเละใส่ URL : https://localhost:44306/universities/4
เเละทำการใส่ข้อมูลที่ต้องการเเก้ไขในรูปแบบ JSON
ตัวอย่างข้อมูลในรูปแบบ JSON ที่ใช้ในการเเก้ไขข้อมูล (เปลี่ยนจาก "name": "KU" เป็น "name": "KMUTNB")
{
	"universityId": 4,
	"name": "KMUTNB"
}
เมื่อกด Send ก็จะเป็นการเปลี่ยนค่า name ที่เป็นชื่อของมหาวิทยาลัยจาก KU ไปเป็น KMUTNB เเละบันทึกลงใน  database (ทำตามข้อ 1. เพื่อดูการเปลี่ยนแปลง)

5.) เมื่อใช้  method DELETE เเละใส่ URL : https://localhost:44306/universities/:id  ใน Postman จะเป็นการลบข้อมูลทั้งหมดของมหาวิทยาลัยที่มี id ตรงกับใน database
ตัวอย่างเช่น ใช้ method DELETE เเละ URL : https://localhost:44306/universities/4 เมื่อทำการกด Send จะเป็นการลบข้อมูลทั้งหมดของมหาวิทยาลัยที่มี id เท่ากับ 4 ใน database (ทำตามข้อ 1. เพื่อดูการเปลี่ยนแปลง)

6.) เมื่อใช้  method GET เเละใส่ URL : https://localhost:44306/students ใน Postman เเละทำการกด Send ตัว API
จะทำการ return ข้อมูลของนักศึกษาทั้งหมดที่อยู่ใน database ในรูปแบบของ JSON
ตัวอย่าง JSON ที่ return กลับมาจาก API (เฉพาะข้อมูลจาก sample data)
[
    {
        "studentId": 6013110,
        "firstName": "Annie",
        "lastName": "Ant"
    },
    {
        "studentId": 6013111,
        "firstName": "Brownie",
        "lastName": "Bee"
    },
    {
        "studentId": 6013112,
        "firstName": "Catie",
        "lastName": "Cat"
    }
]

7.) เมื่อใช้  method GET เเละใส่ URL : https://localhost:44306/students/:id ใน Postman เมื่อทำการกด  Send ตัว API
จะทำการ return ข้อมูลของนักศึกษาที่มี id ตรงกับใน database พร้อมทั้งรายชื่อของมหาวิทยาลัยที่นักศึกษาศึกษาอยู่ทั้งหมดในรูปแบบของ JSON
ตัวอย่าง JSON ที่ return กลับมาจาก API เมื่อใช้ method GET เเละ URL : https://localhost:44306/students/6013111 (เฉพาะข้อมูลจาก sample data)
[
    {
        "studentId": 6013111,
        "firstName": "Brownie",
        "lastName": "Bee",
        "universities": [
            {
                "name": "MU"
            },
            {
                "name": "CU"
            }
        ]
    }
]

8.) เมื่อใช้  method POST เเละใส่ URL : https://localhost:44306/students ใน Postman จะเป็นการเพิ่มข้อมูลของนักศึกษาเข้าไปใน database
โดยจะต้องทำการใส่ข้อมูลที่ต้องการเพิ่มในรูปแบบของ JSON ใน Postman ก่อน โดยการเลือกใส่ข้อมูลที่ต้องการเพิ่มจะทำเช่นเดียวกันกับในข้อ 3.
ตัวอย่างข้อมูลในรูปแบบ JSON ที่ใช้ในการเพิ่มข้อมูล
{
        "studentId": 6013113,
        "firstName": "Dobie",
        "lastName": "Doo"
}

เมื่อกด Send ก็จะเป็นการเพิ่มข้อมูลลงใน database (ทำตามข้อ 6. เพื่อดูการเปลี่ยนแปลง)

9.) เมื่อใช้  method PUT เเละใส่ URL : https://localhost:44306/students/:id ใน Postman จะเป็นการเเก้ไขข้อมูลของนักศึกษาที่มี id ตรงกับใน database
โดยจะต้องทำการใส่ข้อมูลที่ต้องการจะเเก้ไขก่อนกด Send โดยข้อมูลดังกล่าวจะต้องเป็นข้อมูลในรูปแบบ JSON วิธีการใส่ข้อมูลที่ต้องการเเก้ไขจะทำเช่นเดียวกันกับในข้อ 3.
ตัวอย่างการเเก้ไขข้อมูลของนักศึกษาที่มี id เท่ากับ 6013112 ใน database ใช้ method PUT เเละใส่ URL : https://localhost:44306/students/6013112
เเละทำการใส่ข้อมูลที่ต้องการเเก้ไขในรูปแบบ JSON
ตัวอย่างข้อมูลในรูปแบบ JSON ที่ใช้ในการเเก้ไขข้อมูล (เปลี่ยนจาก "firstName": "Catie" เป็น "firstName": "Cartoon")
{
    "studentId": 6013112,
    "firstName": "Cartoon",
    "lastName": "Cat"
}
เมื่อกด Send ก็จะเป็นการเปลี่ยนค่า firstName ที่เป็นชื่อของนักศึกษาจาก Catie ไปเป็น Cartoon เเละบันทึกลงใน  database (ทำตามข้อ 6. เพื่อดูการเปลี่ยนแปลง)

10.) เมื่อใช้ method DELETE เเละใส่ URL : https://localhost:44306/students/:id  ใน Postman จะเป็นการลบข้อมูลทั้งหมดของนักศึกษาที่มี id ตรงกับใน database
ตัวอย่างเช่น ใช้ method DELETE เเละ URL : https://localhost:44306/students/6013112 เมื่อทำการกด Send จะเป็นการลบข้อมูลทั้งหมดของนักศึกษาที่มี id เท่ากับ 6013112 ใน database (ทำตามข้อ 6. เพื่อดูการเปลี่ยนแปลง)

วิธีการเพิ่ม sample data สามารถทำได้ 2 วิธีคือ
1.)  เพิ่ม sample data โดยการใช้ method POST ในโปรเเกรม Postman โดยจะทำเช่นเดียวกันทั้งข้อมูล Students, Universities เเละ Enrolls
ตัวอย่างการเพิ่มข้อมูล Enrolls ที่เป็นข้อมูลที่บอกว่านักศึกษา id ไหนกำลังศึกษาอยู่ในมหาวิทยาลัยไหนในระดับการศึกษาใด
ใช้ method POST ใส่ URL : https://localhost:44306/enrolls เเละใส่ข้อมูลที่ต้องการเพิ่มในรูปแบบ  JSON เช่น
{
        "studentId": 6013110,
        "universityId": 3,
        "degree": "Master"
}
หมายเหตุ สามารถใช้ method GET, POST, PUT เเละ DELETE กับข้อมูล Enrolls ได้เหมือนกันกับข้อมูล Students เเละ Universities

2.) เพิ่ม sample data โดยการเพิ่ม code ใน file ที่ชื่อ DbInitializer.cs ใน Folder Models โดยหากเเก้ไขโค้ดใน file นี้จะเป็นการเพิ่ม sample data ให้กับ database เเค่เพียงตอนสร้าง database ใหม่ครั้งเเรกเท่านั้น