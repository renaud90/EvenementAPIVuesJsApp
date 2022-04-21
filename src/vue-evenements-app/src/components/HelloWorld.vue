<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <p>Cette application utilise les technologies .NET et VUE.JS.</p>
    <h3>NOTRE ÉQUIPE</h3>
    <div class="team">
      <div class="member">
        <img class="" alt="logo" src="../assets/mohammed.jpg" />
        <span> <strong>Mohammed Jalaleddine</strong> </span>
      </div>
      <div class="member">
        <img class="" alt="logo" src="../assets/renaud.jpg" />
        <span> <strong>Renaud Lussier</strong> </span>
      </div>
    </div>
  </div>
</template>

<script>
import httpClient from "../api/httpClient.js";
export default {
  name: "HelloWorld",
  props: {
    msg: String,
  },
  data() {
    return {
      todos: [],
    };
  },
  created() {
    httpClient
      .get(`/Evenements`)
      .then((response) => {
        this.todos = response.data;
        alert("succes de la requete!!!");
      })
      .catch((error) => {
        console.log(error);
      });
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

.team {
  display: flex;
  justify-content: center;
}
.member {
  display: flex;
  width: 20%;
  flex-direction: column;
  margin: 2%;
}
img {
  margin: 2%;
  border-radius: 10%;
}
</style>
