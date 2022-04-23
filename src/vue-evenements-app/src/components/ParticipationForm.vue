<template>
    <div>
        <div id="formulaireInscription">
            <h3> Formulaire d'inscription pour l'événement: {{this.nomEvenement}} </h3>
                <div>
                <label>Nom:* </label><input v-model="this.nomParticipant" type="text" placeholder="Doe"/>
                </div>
                <br>
                <div>
                <label>Prénom:* </label><input v-model="this.prenomParticipant" type="text" placeholder="John"/>
                </div>
                <br>
                <div>
                <label>Courriel:* </label><input v-model="this.courriel" type="text" placeholder="JohnDoe@email.com"/>
                </div>
                <br>
                <div>
                <label>Nombre de places à réserver:* </label><input v-model="this.nbPlaces" type="number">
                </div>
                <br>
                <div>
                <button class="fermer" >
                <router-link to="/evenements">Annuler</router-link>
                </button>
                <button  @click="ajouterParticipation()" :disabled="!this.canAddParticipation">
                Je participe!
                </button>
                *Champs requis
                </div>
        </div>
    </div>
</template>

<script>
import httpClient from '../api/httpClient.js'
import { mapState, mapMutations } from 'vuex';
import router from '../router/index.js'
export default {
  name: "ParticipationForm",
  props: {
  },
  data() {
    return {
        nomEvenement: "",
        prenomParticipant: "",
        nbPlaces: 0,
        courriel: "",
        idEvenement: parseInt(this.$route.params.id),
        nomParticipant: "",
    };
  },
  methods:{
      ...mapMutations({addParticipation: 'addParticipation'}),
      ajouterParticipation(){
          httpClient.post(`/Participations`, {
              nom: this.nomParticipant,
              prenom: this.prenomParticipant,
              courriel: this.courriel,
              nbPlaces: this.nbPlaces,
              evenementId: this.idEvenement
          })
          .then(() => {
            this.addParticipation({
                idEvenement:this.idEvenement, 
                nbPlaces:this.nbPlaces
                });
            alert("Participation ajoutée!");
            router.push('/evenements');
          })
          .catch(e =>{
              console.log(e);
              alert('Une erreur est survenue.');
          })
        
      }
  },
  computed:{
      ...mapState({evenements: 'evenements'}),
      canAddParticipation(){
          return this.nomParticipant !== "" && this.prenomParticipant !== "" && this.courriel !== "" && this.nbPlaces > 0;
      },
      
  },
  created(){
          this.nomEvenement = this.evenements.filter((x) => x.id == this.idEvenement)[0].titre;
  }
}
</script>

<style>

    #formulaireInscription{
        width:800px;
        padding:5px;
        margin-bottom:10px;
        margin:auto;
        border: 2px solid black;
        border-radius: 5px;
    }
</style>
