<template>
    <div class="evenementsTable">
        <table border = 1>
            <tr id="headerRow">
                <th id="titreCol">Titre</th>
                <th id="villeCol">Ville</th>
                <th id="participationsCol">Nb de participations</th>
                <th id="prixCol">Prix</th>
                <th id="categoriesCol">Catégories</th>
                <th id="periodeCol">Période</th>
                <th id="actionCol">Action</th>
            </tr>
            <tr v-for="(e, index) in evenements" :key="index">
                <td>{{e.description}}</td>
                <td>{{e.ville}}</td>
                <td>{{e.nbParticipations}}</td>
                <td>{{e.prix === 0 ? "Gratuit" : e.prix + "$"}}</td>
                <td>{{e.categories === "" ? "Aucune" : e.categories}}</td>
                <td>{{"Début: " + new Date(e.dateDebut).toLocaleString("en-US")}} <br> {{"Fin: " + new Date(e.dateFin).toLocaleString("en-US")}}</td>
                <td>
                    <img class="actionButton" src="../assets/icons/plus.png" title="Détails"/>
                    <img class="actionButton" src="../assets/icons/participate.png" title="Participer"/>
                    <img class="actionButton" src="../assets/icons/delete.png" title="Supprimer"/>
                </td>
            </tr>
        </table>
    </div>
</template>

<script>
import { mapState, mapMutations } from 'vuex';
//import httpClient from '../api/httpClient.js'
export default {
    name: 'EvenementsTable',
    props: {
    
    },
    data() {
        return {
        }
    },
    created(){
        this.loadAllEvenements();
    },
    methods:{
        ...mapMutations({getAllEvenements: 'getAllEvenements'}),
        loadAllEvenements(){
            if(this.evenements.length === 0){
                this.getAllEvenements()
            }
        }
    },
    computed: {
        ...mapState({evenements: 'evenements'})
    }
}
</script>

<style>
    td, th{
        padding:5px 5px;
    }
    .evenementsTable{
        width:800px;
        margin:auto;
    }
    .actionButton{
        cursor:pointer;
        display: inline-block;
        width: 20px;
        height: 20px;
        padding:0px 5px;
    }
    #actionCol{
        width:100px;
    }
</style>