<template>
  <div>
    <button @click="sho = true">Afficher</button>
    <div v-if="sho" class="englob">
      <div class="describ">
        <h3>{{ this.evenement.titre }}</h3>
        <p>
          {{ this.evenement.description }}
        </p>
        <div class="plus">
          <div class="info">
            <p>
              {{
                this.evenement.categories === ""
                  ? "Aucune"
                  : this.evenement.categories
              }}
            </p>
          </div>
          <div class="info">
            <p>
              {{
                this.evenement.prix === 0
                  ? "Gratuit"
                  : this.evenement.prix + "$"
              }}
            </p>
          </div>
          <div class="info">
            <p>Participation {{ this.evenement.nbParticipations }}</p>
          </div>
        </div>
        <div class="date">
          <div><p>De&#160;</p></div>
          <div>
            <p>{{ this.evenement.dateDebut }}</p>
          </div>
          <div><p>&#160;Au&#160;</p></div>
          <div>
            <p>{{ this.evenement.dateFin }}</p>
          </div>
        </div>
        <button class="fermer" v-on:click="sho = false">
          <div>Fermer</div>
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";
//import httpClient from '../api/httpClient.js'
export default {
  name: "EvenementsDetails",
  props: { id: Number },
  data() {
    return {
      sho: false,
      evenement: this.evenements.select((x) => x.id === this.id)[0],
    };
  },

  methods: {},
  computed: {
    ...mapState({ evenements: "evenements" }),
  },
};
</script>

<style>
.englob {
  display: flex;
  flex-direction: column;
  justify-content: center;

  z-index: 100;
  justify-items: center;
  place-items: center;
}

.date {
  display: flex;
  flex-direction: row;
  justify-content: center;
  width: 300px;
  background-color: green;
  border-radius: 3%;
  margin: 2%;
}

.describ {
  display: flex;
  flex-direction: column;
  justify-content: center;
  border-radius: 2%;
  justify-items: center;
  place-items: center;
  color: white;
  background-color: skyblue;
  padding: 3%;
  width: 60%;
}
.plus {
  display: flex;
  flex-direction: row;
  justify-content: center;
}
.info {
  margin: 1%;
  background-color: green;
  width: 100px;
  height: 50px;
  color: white;
  border-radius: 10px;
  place-items: center;
  padding: 5px;
}

.fermer {
  background-color: red;
  color: azure;
  width: 10%;
  border-radius: 10%;
}
</style>
