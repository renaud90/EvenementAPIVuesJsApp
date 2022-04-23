import { createStore } from 'vuex'
import httpClient from '../api/httpClient.js'
export default createStore({
  state: {
    evenements:[]
  },
  getters: {
  },
  mutations: {
    getAllEvenements(state){
      httpClient.get(`/Evenements`)
        .then((response) => {
            state.evenements  = response.data;
            state.evenements.forEach(element => {
                httpClient.get(`/Villes/` + element.villeId)
                .then((response) => {
                    element.ville = response.data.nom
                })
                httpClient.get(`/Evenements/` + element.id + `/participations`)
                .then(response => {
                    element.nbParticipations = 0
                    let p = response.data.map(_ => _.nbPlaces)
                    p.forEach(e => {
                        element.nbParticipations += e
                    })
                })
                element.categories = ""
                element.categoriesId.forEach(id => {
                    httpClient.get(`/Categories/` + id)
                    .then(response => {
                        element.categories += response.data.nom + " "
                    })
                })
            })
        })
        .catch((error) => {
            console.log(error);
        })
    },
    deleteEvenement(state, id){
        this.state.evenements = this.state.evenements.filter(_ => _.id != id)
    },
    addParticipation(state, data){
        console.log(data.nbPlaces);
        this.state.evenements.filter(_ => _.id == data.idEvenement)[0].nbParticipations += data.nbPlaces;
        //console.log(this.state.evenements.filter(_ => _.id == idEvenement)[0].nbParticipations);
    }
  },
  actions: {
  },
  modules: {
  }
})
