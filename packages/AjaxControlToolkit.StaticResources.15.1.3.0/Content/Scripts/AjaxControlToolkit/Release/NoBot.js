﻿Type.registerNamespace("Sys.Extended.UI");Sys.Extended.UI.NoBotBehavior=function(n){Sys.Extended.UI.NoBotBehavior.initializeBase(this,[n]);this._ChallengeScript=""};Sys.Extended.UI.NoBotBehavior.prototype={initialize:function(){Sys.Extended.UI.NoBotBehavior.callBaseMethod(this,"initialize");var response=eval(this._ChallengeScript);Sys.Extended.UI.NoBotBehavior.callBaseMethod(this,"set_ClientState",[response])},dispose:function(){Sys.Extended.UI.NoBotBehavior.callBaseMethod(this,"dispose")},get_ChallengeScript:function(){return this._ChallengeScript},set_ChallengeScript:function(n){this._ChallengeScript!=n&&(this._ChallengeScript=n,this.raisePropertyChanged("ChallengeScript"))}};Sys.Extended.UI.NoBotBehavior.registerClass("Sys.Extended.UI.NoBotBehavior",Sys.Extended.UI.BehaviorBase);