<template>
<div class="Registration">
  <h1>Запись на приём</h1>
  <div class="RegistrationCard">
    <div class="RegistrationInput">
      <label for="userName">Ваше имя:</label>
      <input id="userName" type="text" v-model="registerData.name">
    </div>
    <div class="RegistrationInput">
      <label for="doctorSpeciality">Специальность врача:</label>
      <select v-model="registerData.doctorData.specialty"
              :disabled="!registerData.name"
              id="doctorSpeciality"
      >
        <option v-for="specialty in specialties"
                :key="specialty.id"
                :value="specialty"
        >
          {{specialty.specialty}}
        </option>
      </select>
    </div>
    <div class="RegistrationInput">
      <label for="doctorPerson">ФИО врача:</label>
      <select v-model="registerData.doctorData.doctor"
              :disabled="!registerData.doctorData.specialty"
              id="doctorPerson"
              v-if="registerData.doctorData.specialty"
      >
        <option v-for="doctor in doctors.filter((el) => el.specialty === registerData.doctorData.specialty.specialty)"
                :key="doctor.id"
                :value="doctor"
        >
          {{doctor.name}}
        </option>
      </select>
      <select v-else disabled></select>
    </div>
    <div class="RegistrationInput">
      <label for="doctorService">Услуга:</label>
      <select v-model="registerData.doctorData.service"
              :disabled="!registerData.doctorData.doctor"
              id="doctorService"
              v-if="registerData.doctorData.doctor"
      >
        <option v-for="service in services.filter(el => el.specialty === registerData.doctorData.specialty.specialty)"
                :key="service.id"
                :value="service"
        >
          {{service.service}}
        </option>
      </select>
      <select v-else disabled></select>
    </div>
    <div class="RegistrationInput">
      <label for="date">Дата:</label>
      <select v-model="registerData.date"
              :disabled="!registerData.doctorData.service"
              id="date"
              v-if="registerData.doctorData.service"
      >
        <option v-for="date in timetable.filter(el => el.doctors.map(doc => doc.name).includes(registerData.doctorData.doctor.name))"
                :key="date.id"
                :value="date"
        >
          {{date.date}}
        </option>
      </select>
      <select v-else disabled></select>
    </div>
    <div class="RegistrationInput">
      <label for="time">Время:</label>
      <select v-model="registerData.time"
              :disabled="!registerData.date"
              id="time"
              v-if="registerData.date"
      >
        <option v-for="(time, key) in registerData.date.doctors.filter(el => el.name === registerData.doctorData.doctor.name)[0].times"
                :key="key"
                :value="time"
        >
          {{time.time}}
        </option>
      </select>
      <select v-else disabled></select>
    </div>

    <div class="RegistrationAction">
      <h5>
        Цена:
        <template v-if="registerData.time">
          {{registerData.doctorData.service.price}} рублей
        </template>
        <template v-else>
          -
        </template>
      </h5>
      <button class="btn btn-success" @click ="onSave">
        Сохранить
      </button>
    </div>
  </div>
</div>
</template>

<script>
import json from '../../db.json';

export default {
  data(){
    return{
      appointments: json.appointments,
      doctors: json.personal,
      services: json.services,
      specialties: json.specialties,
      timetable: json.timetable,
      registerData: {
        name: "",
        doctorData: {
          specialty: null,
          doctor: null,
          service: null,
        },
        date: null,
        time: null,
      }
    }
  },
  methods: {
    onSave(){
      let appointments = {
        id: this.appointments.length + 1,
        name: this.registerData.name,
        specialty: this.registerData.doctorData.specialty.specialty,
        doctor: this.registerData.doctorData.doctor.name,
        service: this.registerData.doctorData.service.service,
        price: this.registerData.doctorData.specialty.price,
        time: this.registerData.time.time,
        date: this.registerData.date.date
      };

      this.$http.post("http://localhost:3000/appointments", appointments)
        .then(res => {
            alert('Вы успешно записались на прием!');
            console.log(res)
          });
    }
}  
      
    }

  
</script>

<style scoped>
  h1{
    margin-left: 16px;
  }
  .Registration{
    display: flex;
    flex-direction: column;
  }
  .RegistrationCard{
    width: 400px;
    padding: 16px;
    display: flex;
    flex-direction: column;
  }
  .RegistrationInput{
    margin-top: 8px;
    margin-bottom: 8px;
  }
  .RegistrationInput input, .RegistrationInput select {
    width: 100%;
  }
  .RegistrationAction{
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-top: 16px;
  }
  .RegistrationAction h5{
    margin: 0;
  }
</style>
